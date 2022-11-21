import { Field, Form, Formik } from "formik";
import React from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
import { ApiResponse, BetCreateDto, BetGetDto } from "../../../constants/types";
import axios from "axios";



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
      <Header>Create New Bet</Header>
      <Formik onSubmit={onSubmit} initialValues={{} as BetCreateDto}>
        <Form>
          <div>
            <div>
              <div className="Field-label">
                <label htmlFor="name">Name</label>
              </div>
              <Field className="field" id="name" name="name" >
                {({ field }) => <Input {...field} />}
              </Field>
              
              <div>Bet Category</div>
              <Field className="field" number="id" name="betCategoryId"  >
                {({ field }) => <Input type="number" {...field} />}
              </Field>
            </div>
          </div>
          <div>
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
        </Form>
      </Formik>
    </>
  );
};
