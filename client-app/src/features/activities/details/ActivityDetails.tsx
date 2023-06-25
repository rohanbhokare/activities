import React, { useEffect } from 'react';
import { Button, ButtonGroup, Card, Image } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { NavLink, useParams } from 'react-router-dom';
import { observer } from 'mobx-react-lite';

export default observer(function ActivityDetails () {
    const {activityStore} = useStore();
    const {selectedActivity: activity, loadActivity, loadingInitial } = activityStore;
    const {id} = useParams();

    useEffect(() => {
        if(id) loadActivity(id)
    }, [id, loadActivity])
    

    if( loadingInitial || !activity) return <LoadingComponent />;
    return (


        <Card fluid>
            <Image src={`/assets/categoryImages/${activity.category}.jpg`} />
            <Card.Content>
                <Card.Header>{activity.title}</Card.Header>
                <Card.Meta>
                    <span>{activity.date}</span>
                </Card.Meta>
                <Card.Description>
                    {activity.description}
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <ButtonGroup widths='2'>
                    <Button as={NavLink} to={`/manage/${activity.id}`} basic color='blue' content="Edit"  />
                    <Button as={NavLink} to='/activities' basic color='grey' content="Cancel" />
                </ButtonGroup>
            </Card.Content>
        </Card>
    );
});