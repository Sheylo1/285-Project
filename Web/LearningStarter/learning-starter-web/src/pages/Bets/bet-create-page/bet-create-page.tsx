import { Field, Form, Formik } from "formik";
import React from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
import { ApiResponse, BetCreateDto, BetGetDto } from "../../../constants/types";
import axios from "axios";
import { BaseUrl } from "../../../constants/env-vars";


export const BetsCreatePage = () => {
  const history = useHistory();

  const onSubmit = async (values: BetCreateDto) => {
    const response = await axios.post<ApiResponse<BetGetDto>>(
      `${BaseUrl}/api/bets/create`, values
    );
    
    

    if (response.data.hasErrors) {
      alert("Lol u though this would work idiot");
      return;
    }

    alert("nothing exploded, bet created");
    history.push(routes.bet);
  };

  return (
    <>
      <Header>Create New Bet</Header>
      <Formik onSubmit={onSubmit} initialValues={{} as BetCreateDto}>
        <Form>
          <div>
            <div>
              <div className="Field-label">
                <label htmlFor="=id">Id</label>
              </div>
              <Field className="field" id="id" name="Name" >
                {({ field }) => <Input {...field} />}
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
