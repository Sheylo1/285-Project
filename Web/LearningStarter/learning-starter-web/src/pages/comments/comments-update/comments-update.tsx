import { Field, Form, Formik } from "formik";
import React from "react";
import { Header, Input, Button } from "semantic-ui-react";
import { useHistory, useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import {
  ApiResponse,
  CommentCreateDto,
  CommentDeleteDto,
  CommentGetDto,
  CommentUpdateDto,
} from "../../../constants/types";
import axios from "axios";
import { BaseUrl } from "../../../constants/env-vars";
import "./comments-update.css";

export const CommentsUpdatePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
  const history = useHistory();

  const onSubmit = async (values: CommentUpdateDto) => {
    const response = await axios.put<ApiResponse<CommentGetDto>>(
      `/api/comments/${id}`,
      values
    );

    if (response.data.hasErrors) {
      response.data.errors.forEach((err) => {
        console.log(err.message);
      });
    } else {
      history.push(routes.comment);
    }
  };

  return (
    <>
      <h2 className="update-header">Update Your Comment</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as CommentUpdateDto}>
        <Form>
        <div className="update-centertext">
        <h3 className="small-header">
                Update Message</h3>
        </div>
          <div>
            <div>
              <div className="update-header">
              <Field className="field" id="commentText" name="commentText">
                {({ field }) => <Input placeholder="Type a message" type="commentText" {...field} />}
              </Field>
              </div>
            </div>
          </div>
          <div>
            <div className="update-buttons">
            <Button primary type="submit">
              Submit
            </Button>
            <Button
              secondary
              type="button"
              onClick={() => history.push(routes.comment)}
            >
              Cancel
            </Button>
            </div>
          </div>
        </Form>
      </Formik>
      <h3 className="allaroundred">Must enter at least 3 char and less than 65 char</h3>
    </>
  );
};
