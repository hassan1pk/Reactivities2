import { observer } from 'mobx-react-lite';
import React, { Fragment } from 'react'
import { Header } from 'semantic-ui-react'
import { useStore } from '../../../App/sotres/store';
import ActivityListeItem from './ActivityListeItem';


function ActivityList() {

    const { activityStore } = useStore();
    const { groupedActivities } = activityStore;

    return (
        <>
            {groupedActivities.map(([group, activities]) => (
                <Fragment key={group}>
                    <Header sub color='teal'>
                        {group}
                    </Header>
                    {activities.map((activity) => (
                        <ActivityListeItem key={activity.id} activity={activity} />
                    ))}

                </Fragment>
            ))}
        </>

    )
}

export default observer(ActivityList);
