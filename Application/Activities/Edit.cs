using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Acitivty { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Acitivty.Id);

                //activity.Title = request.Acitivty.Title ?? activity.Title;
                //activity = _mapper.Map(request.Acitivty, activity);

                activity = _mapper.Map<Activity>(request.Acitivty);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}