import React, { ChangeEvent, useState } from 'react';
import { Button, Form, Segment } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';


interface Props {
    closeForm: () => void;
    activity: Activity | undefined;
    createOrEdit: (activity: Activity) => void;
    submitting: boolean
}

export default function ActivityForm ({closeForm, activity: selectActivity, submitting, createOrEdit}: Props) {
    const initialState = selectActivity ?? {
        id: '',
        title: '',
        category: '',
        description: '',
        date: '',
        city:'', 
        venue:''
    }

    const [activity, setActivities] = useState(initialState);

    function handleSubmit () {
        console.log(activity); 
        createOrEdit(activity);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setActivities({...activity, [name]: value})
    }

    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete="off">
                <Form.Input placeholder="Title" value={activity.title} name='title' onChange={handleInputChange}  />
                <Form.TextArea placeholder="Description" value={activity.description} name='description' onChange={handleInputChange} />
                <Form.Input placeholder="Category" value={activity.category} name='category' onChange={handleInputChange} />
                <Form.Input placeholder="Date" type='date' value={activity.date} name='date' onChange={handleInputChange} />
                <Form.Input placeholder="City" value={activity.city} name='city' onChange={handleInputChange} />
                <Form.Input placeholder="Venu" value={activity.venue} name='venue' onChange={handleInputChange} />
                <Button loading={submitting} floated='right' positive type='submit' content="Submit" /> 
                <Button  onClick={closeForm} floated='right' type='button' content="Cancel" /> 
            </Form>
        </Segment>
    )
}