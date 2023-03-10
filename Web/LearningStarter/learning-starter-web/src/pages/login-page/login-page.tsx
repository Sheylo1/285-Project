import "./login-page.css";
import axios from "axios";
import React, { useMemo, useState } from "react";
import { ApiResponse, UserCreateDto, UserDto } from "../../constants/types";
import { Formik, Form, Field } from "formik";
import { Button, Header, Icon, Input, Modal } from "semantic-ui-react";
import { useAsyncFn } from "react-use";
import { PageWrapper } from "../../components/page-wrapper/page-wrapper";
import { loginUser } from "../../authentication/authentication-services";
import SemanticDatepicker from "react-semantic-ui-datepickers";
import { useHistory } from "react-router-dom";
import { routes } from "../../routes/config";


const baseUrl = process.env.REACT_APP_API_BASE_URL;

type LoginRequest = {
  userName: string;
  password: string;
};

type LoginResponse = ApiResponse<boolean>;

type FormValues = LoginRequest;

//This is a *fairly* basic form
//The css used in here is a good example of how flexbox works in css
//For more info on flexbox: https://css-tricks.com/snippets/css/a-guide-to-flexbox/
export const LoginPage = () => {
  const originalValues: UserCreateDto = {
    firstName: "",
    lastName: "",
    userName: "",
    accountBalance: 0,
    email: "",
    phoneNumber: "",
    dateOfBirth: undefined,

  };
  const[open, setOpen] = useState(false);
  const history = useHistory();
  const onSubmit = async (values: UserCreateDto) => {


    const response = await axios.post<ApiResponse<UserDto>>(
      "/api/users",
      values
    );

    if (response.data.hasErrors) {
      alert("Account Could Not Be Made!");
      return;
    }else{
            alert("Account Created!");
     history.push(routes.home);
    }
    setOpen(false);

  };
  const initialValues = useMemo<FormValues>(
    () => ({
      userName: "",
      password: "",
    }),
    []
  );

  const [, submitLogin] = useAsyncFn(async (values: LoginRequest) => {
    if (baseUrl === undefined) {
      return;
    }

    const response = await axios.post<LoginResponse>(
      `${baseUrl}/api/authenticate`,
      values
    );

    if (response.data.data) {
      console.log("Successfully Logged In!");
      loginUser();
    }
  }, []);

  return (
    <PageWrapper>
      <div className="flex-box-centered-content-login-page">
        <div className="login-form">
          <Formik initialValues={initialValues} onSubmit={submitLogin}>
            <Form>
              <div>
                <div>
                  <div className="loginpage1-header">
                    <label htmlFor="userName">UserName</label>
                  </div>
                  <div className="loginpage1-header">
                  <Field className="fixwhitetext" id="username" name="username">
                    {({ field }) => <Input placeholder= "username" type="username" {...field} />}
                  </Field>
                  </div>
                </div>
                <div>
                  <div className="loginpage1-header">
                    <label htmlFor="password">Password</label>
                  </div>
                  <div className="loginpage1-header">
                  <Field className="field" id="password" name="password">
                    {({ field }) => <Input placeholder= "password" type="password" {...field} />}
                  </Field>
                  </div>
                </div>
                <div className="button-container-login-page">
                  <Button color= 'green' className="login-button" type="submit">
                    Login
                  </Button>
                </div>
              </div>
            </Form>
          </Formik>
      <Formik onSubmit={onSubmit} initialValues={originalValues }>
        <div className="loginpage-buttons">
        <Modal 
        closeIcon
        as={Form}
        onOpen={()=> setOpen(true)}
        onClose={()=>setOpen(false)}
        open={open}
        trigger={<Button color="blue">Sign Up</Button>}>
            <Modal.Header>Create Account</Modal.Header>
            <Modal.Content>
            <div>
            <div>
            <div className="paddinglogin">
                <label htmlFor="userId">Date of Birth</label><div className="allaroundredlogin">*Must enter D.O.B.</div>
              </div>
              <Field className="date" id="dateOfBirth" name="dateOfBirth">
                {({field, form}) => <SemanticDatepicker {...field} onChange={(_, { name, value }) =>{
                  console.log("debug",name)
                  console.log("debug",value)
                  form.setFieldValue(name, value)}
                }  />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">First Name</label><div className="allaroundredlogin">*Must enter at least 3 char and less than 33 char</div>
              </div>
              <Field className="field" id="firstName" name="firstName">
                {({ field }) => <Input placeholder= "First Name" minlength="2" maxlength="32" required {...field} />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">Last Name</label><div className="allaroundredlogin">*Must enter at least 3 char and less than 33 char</div>
              </div>
              <Field className="field" id="lastName" name="lastName">
                {({ field }) => <Input placeholder= "Last Name" minlength="2" maxlength="32" required {...field} />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">Username</label><div className="allaroundredlogin">*Must enter at least 3 char and less than 33 char</div>
              </div>
              <Field className="field" id="userName" name="userName">
                {({ field }) => <Input placeholder= "Username" minlength="2" maxlength="32" required {...field} />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">Email</label><div className="allaroundredlogin">*Must enter at least 3 char</div>
              </div>
              <Field className="field" id="email" name="email">
                {({ field }) => <Input type="email" placeholder= "Email" minlength="3" required {...field} />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">Password</label><div className="allaroundredlogin">*Must enter at least 6 char</div>
              </div>
              <Field className="field" id="password" name="password">
                {({ field }) => <Input placeholder= "Password" type="password" minlength="6" required {...field} />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">Re-enter Password</label><div className="allaroundredlogin">*Passwords must match!</div>
              </div>
              <Field className="field" id="password" name="re-enter password">
                {({ field }) => <Input placeholder= "Re-enter Password" type="password" minlength="6" maxlength="32" required {...field} />}
              </Field>
              <div className="paddinglogin">
                <label htmlFor="userId">Phone Number</label><div className="allaroundredlogin">*Max of 11 integers</div>
              </div>
              <Field className="field" id="phoneNumber" name="phoneNumber">
                {({ field }) => <Input type="tel" placeholder= "Phone Number" maxlength="11" {...field} />}
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
               onClick={() => setOpen(false)}
            >
              Cancel
            </Button>
          </div> 
            </Modal.Actions>


        </Modal>
        </div>
      </Formik>
        </div>
      </div>
    </PageWrapper>
  );
};
function preventDefault() {
  throw new Error("Function not implemented.");
}