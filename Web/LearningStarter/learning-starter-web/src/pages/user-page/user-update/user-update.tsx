import { Field, Form, Formik } from "formik";
import React from "react";
import { Header, Input, Button } from "semantic-ui-react";
import { useHistory, useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import {
  ApiResponse,
  UserDto,
  UserUpdateDto,
} from "../../../constants/types";
import axios from "axios";
import { BaseUrl } from "../../../constants/env-vars";
import { useUser } from "../../../authentication/use-auth";
import SemanticDatepicker from "react-semantic-ui-datepickers";

export const UserUpdatePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
  const history = useHistory();
  const user = useUser();

  const onSubmit = async (values: UserUpdateDto) => {
    const response = await axios.put<ApiResponse<UserDto>>(
      `/api/users/update/${id}`,
      values
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
      <h2 className="update-header">Update Your Profile</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as UserUpdateDto}>
        <Form>
        <div className="update-centertext">
        <h3 className="small-header">
                Update User</h3>
        </div>
        <div>
            <div>
            <div className="field-label">
                <label htmlFor="userId">Date of Birth</label>
              </div>
              <Field className="date" id="dateOfBirth" name="dateOfBirth">
                {({field, form}) => <SemanticDatepicker {...field} onChange={(_, { name, value }) =>{
                  console.log("debug",name)
                  console.log("debug",value)
                  form.setFieldValue(name, value)}
                }  />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">First Name</label>
              </div>
              <Field className="field" id="firstName" name="firstName">
                {({ field }) => <Input error={{ content: 'Please enter your first name', pointing: 'below' }} placeholder= "First Name" {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Last Name</label>
              </div>
              <Field className="field" id="lastName" name="lastName">
                {({ field }) => <Input error={{ content: 'Please enter your last name', pointing: 'below' }} placeholder= "Last Name" {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Username</label>
              </div>
              <Field className="field" id="userName" name="userName">
                {({ field }) => <Input error={{ content: 'Please enter your username', pointing: 'below' }} placeholder= "Username" {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Email</label>
              </div>
              <Field className="field" id="email" name="email">
                {({ field }) => <Input error={{ content: 'Please enter your email', pointing: 'below' }} placeholder= "Email" {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Password</label>
              </div>
              <Field className="field" id="password" name="password">
                {({ field }) => <Input error={{ content: 'Please enter your password', pointing: 'below' }} placeholder= "Password" type="password" {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Phone Number</label>
              </div>
              <Field className="field" id="phoneNumber" name="phoneNumber">
                {({ field }) => <Input error={{ content: 'Please enter your phonenumber', pointing: 'below' }} placeholder= "Phone Number" {...field} />}
              </Field>
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
