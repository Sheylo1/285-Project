import { Field, Form, Formik } from "formik";
import React from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
import { ApiResponse, BetCreateDto, BetGetDto } from "../../../constants/types";
import axios from "axios";
import "./bet-create-page.css";



export const BetsCreatePage = () => {
  const history = useHistory();

  const onSubmit = async (values: BetCreateDto) => {
    const response = await axios.post<ApiResponse<BetGetDto>>(
      `/api/Bet`, values
    );
    
    

    if(response.data.hasErrors) {
      response.data.errors.forEach((err) => {
       console.log(err.message);
      });
   } else {
       history.push(routes.bet)
   }
  }

  return (
    <>
      <h2 className="betcreate-header">Create New Bet</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as BetCreateDto}>
        <Form>
          <div>
            <div>
            <div className="betcreate1-header">
                <label htmlFor="name">Name</label>
              </div>
              <div className="betcreate1-header">
              <Field className="field" id="name" name="name" >
                {({ field }) => <Input placeholder="Bet Name" {...field} />}
              </Field>
              </div>
              <div className="betcreate1-header">
                <label htmlFor="name">Bet Category</label>
              </div>
              <div className="betcreate1-header">
              <Field className="field" number="id" name="betCategoryId"  >
                {({ field }) => <Input placeholder="Bet Category" type="number" {...field} />}
              </Field>
              </div>
            </div>
          </div>
          <div>
          <div className="employeecreate-buttons">
            <Button primary type="submit">
              Submit
            </Button>
            <Button
              secondary
              type="button"
              onClick={() => history.push(routes.bet)}
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
