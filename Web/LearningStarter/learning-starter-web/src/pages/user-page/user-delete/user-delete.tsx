import { Field, Form, Formik } from "formik";
import React from "react";
import { Header, Input, Button } from "semantic-ui-react";
import { useHistory, useParams, useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import {
  ApiResponse,
  UserDeleteDto,
  UserDto,
} from "../../../constants/types";
import axios from "axios";
import { BaseUrl } from "../../../constants/env-vars";
import { useUser } from "../../../authentication/use-auth";
import { logoutUser } from "../../../authentication/authentication-services";


export const UserDeletePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const user = useUser();
  const id = match.params.id;
  const history = useHistory();

  const onSubmit = async (values: UserDeleteDto) => {
    const response = await axios.delete<ApiResponse<UserDto>>(
      `/api/user/delete/${id}`
      /*,values*/
    );

    if (response.data.hasErrors) {
      response.data.errors.forEach((err) => {
        console.log(err.message);
      });
    } else {
      history.push(routes.user);
    }
  };

  return (
    <>
      <h2 className="delete-header">Delete Your Account</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as UserDeleteDto}>
        <Form>
          <div>
            <div>
              <div className="delete-header">
                <h3 className="small-header">
                  Are you sure you want to proceed? This cannot be undone.
                </h3>
              </div>
            </div>
            <div className="delete-buttons">
              <Button 
              primary
              type="submit"
              onClick={async () => {logoutUser();}}
              >
                Delete
              </Button>
              <Button
                secondary
                type="button"
                onClick={() => history.push(routes.user)}
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
