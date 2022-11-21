import { Field, Form, Formik } from "formik";
import React from 'react';
import { Header, Input, Button } from "semantic-ui-react"; 
import {useHistory} from 'react-router-dom'
import { routes } from "../../../routes/config";
import { ApiResponse, CommentCreateDto, CommentGetDto } from "../../../constants/types";
import axios from "axios";
import { BaseUrl } from "../../../constants/env-vars";
import "./comments-create.css";

export const CommentsCreatePage = () => {
    const history = useHistory();

    const onSubmit = async (values: CommentCreateDto ) => {
        const response = await axios.post<ApiResponse<CommentGetDto>>(
            `/api/comments`
            ,values
            );

        if(response.data.hasErrors) {
           response.data.errors.forEach((err) => {
            alert("Must enter a message");
            console.log(err.message);
           });
        } else {
            history.push(routes.comment)
        }
    }   

    return (
        <>
        <h2 className="update-header">Create Your Comment</h2>
        <Formik onSubmit={onSubmit} initialValues={{} as CommentCreateDto}>
            <Form>
            <div className="update-centertext">
            <h3 className="small-header">
                Create Message</h3>
            </div>
                <div>
                    <div>
                        <div className="create-header">
                        <Field className="field" id="commentText" name="commentText">
                            {({ field }) => <Input placeholder="Create a message" type="commentText" {...field} />}
                        </Field>
                        </div>
                    </div>
                </div>
                <div>
                <div className="update-buttons">
                    <Button 
                        primary
                        type="submit">
                        Submit
                    </Button>
                    <Button
                        secondary
                        type="button"
                        onClick={() => history.push(routes.comment)}>
                        Cancel
                    </Button>
                    </div>
                </div>
            </Form>
        </Formik>
        </>
    )
}