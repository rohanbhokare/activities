import React from 'react';
import { Activity } from '../../../app/models/activity';
import { Button, Item, Label, Segment } from 'semantic-ui-react';

interface Props {
    activities: Activity[];
    selectActivity: (id: string) => void;
    closeForm: () => void;
    deleteActivity: (id: string) => void;
}

export default function ActivityList({activities, selectActivity, closeForm, deleteActivity}: Props) {
    return (
        <Segment>
            <Item.Group divided>
                    { activities.map((activity: Activity) => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as='a'>{activity.title}</Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Description>
                                <div>{activity.description}</div>
                                <div>{activity.city}, {activity.venue}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button  floated='right' content="View" color='blue' onClick={() => {selectActivity(activity.id); closeForm()}} />
                                <Button  floated='right' content="Delete" color='red' onClick={() => deleteActivity(activity.id)} />
                                <Label basic content={activity.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                    ))}
            </Item.Group>
        </Segment>
    );
}