import { Field, Form, Formik } from "formik";
import React from "react";
import { Header, Input, Button } from "semantic-ui-react";
import { useHistory, useParams, useRouteMatch } from "react-router-dom";
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
import "./comments-delete.css";

export const CommentsDeletePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
  const history = useHistory();

  const onSubmit = async (values: CommentDeleteDto) => {
    const response = await axios.delete<ApiResponse<CommentGetDto>>(
      `/api/comments/${id}`
      /*,values*/
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
      <h2 className="delete-header">Delete Your Comment</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as CommentDeleteDto}>
        <Form>
          <div>
            <div>
              <div className="delete-header">
                <h3 className="small-header">
                  Are You Sure You Want To Proceed?
                </h3>
              </div>
            </div>
            <div className="delete-buttons">
              <Button primary type="submit">
                Delete
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
    </>
  );
};
