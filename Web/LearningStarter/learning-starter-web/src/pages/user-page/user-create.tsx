import { Field, Form, Formik } from "formik";
import React, { useState } from "react";
import { Button, Header, Icon, Input, Modal } from "semantic-ui-react";
import { useHistory } from "react-router-dom"
//import { baseUrl } from "../../../constants/env-vars";
import axios from "axios";
import { ApiResponse, UserCreateDto, UserDto } from "../../constants/types";
import { routes } from "../../routes/config";
export const EmployeesCreatePage = () => {
  const initialValues: UserCreateDto = {
    firstName: "John",
    lastName: "Smith",
    userName: "J04n Sm1th",
    accountBalance: 100,
    email: "johnsmith@email.com",
    phoneNumber: "225-523-2523",
    dateOfBirth: "00-00-0000",
    socialId: 1,
  };
  const[open, setOpen] = useState(false);
  const[submitLoading,setSubmitLoading]= useState(false);
  const history = useHistory();
  const onSubmit = async (values: UserCreateDto) => {


    const response = await axios.post<ApiResponse<UserDto>>(
      "/api/user",
      values
    );

    if (response.data.hasErrors) {
      alert("Something went wrong.");
      return;
    }else{
            alert("Nothing went wrong!");
     history.push(routes.user);
    }
    setOpen(false);

  };
  return (
    <>
      <Header>Create New Account</Header>
      <Formik onSubmit={onSubmit} initialValues={initialValues }>
        <Modal as={Form}
        onOpen={()=> setOpen(true)}
        onClose={()=>setOpen(false)}
        open={open}
        trigger={<Button positive><Icon name="add"/></Button>}
        >
            <Modal.Header>Create Account</Modal.Header>
            <Modal.Content>
                         <div>
            <div>
              <div className="field-label">
                <label htmlFor="userId">First Name</label>
              </div>
              <Field className="field" id="firstName" name="firstName">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Last Name</label>
              </div>
              <Field className="field" id="lastName" name="lastName">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Username</label>
              </div>
              <Field className="field" id="userName" name="userName">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Email</label>
              </div>
              <Field className="field" id="email" name="email">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Phone Number</label>
              </div>
              <Field className="field" id="phoneNumber" name="phoneNumber">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Date of Birth</label>
              </div>
              <Field className="field" id="dateOfBirth" name="dateOfBirth">
                {({ field }) => <Input {...field} />}
              </Field>
              <div className="field-label">
                <label htmlFor="userId">Social Id</label>
              </div>
              <Field className="field" id="socialId" name="socialId">
                {({ field }) => <Input {...field} />}
              </Field>
            </div>
          </div> 
            </Modal.Content>
            <Modal.Actions>
          <div>
            <Button
              primary
              type="submit"
               //onClick={() => history.push(routes.employees)}
            >
              Submit
            </Button>
            <Button
              secondary
              type="button"
               onClick={() => history.push(routes.home)}
            >
              Cancel
            </Button>
          </div> 
            </Modal.Actions>


        </Modal>
      </Formik>
    </>
  );
};
