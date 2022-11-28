import axios from "axios";
import { useHistory } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Input } from "semantic-ui-react";
import { ApiResponse, BetGetDto, BetUpdateDto } from "../../../constants/types";
import { useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import "./bet-update-page.css";

export const BetUpdatePagePage = () => {
  const history = useHistory();
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
  const [bets, setBets] = useState<BetGetDto>();
  useEffect(() => {
    const fetchBet = async () => {
      const response = await axios.get<ApiResponse<BetGetDto>>(
        `/api/bet/${id}`
      );

      if (response.data.hasErrors) {
        response.data.errors.forEach((err) => {
          console.log(err.message);
        });
      }

      setBets(response.data.data);
    };

    fetchBet();
  }, [id]);

  const onSubmit = async (values: BetUpdateDto) => {
    const response = await axios.put<ApiResponse<BetUpdateDto>>(
      `/api/Bet/${id}`,
      values
    );

    history.push(routes.bet);
  };

  return (
    <>
    <h2 className="betcreate-header">Update Bet</h2>
      {bets && (
        <Formik initialValues={bets} onSubmit={onSubmit}>
          <Form>
          <div className="betupdate1-header">
              <label htmlFor="name">Name</label>
            </div>
            <div className="betcreate1-header">
            <Field className="field" id="name" name="name">
              {({ field }) => <Input placeholder="Bet Name" {...field} />}
            </Field>
            </div>
            <div>
              <div>
              <div className="betcreate1-header">
                <label htmlFor="betDisputeCall">Dispute This Bet?</label>
              </div>
              </div>
              <div className="betupdate1-header">
              <Field
                className="field"
                id="betDisputeCall"
                name="betDisputeCall"
              >
                {({ field }) => <Input type="checkbox" placeholder="Dispute Value" {...field} />}
              </Field>
              </div>
            </div>
            <div className="employeecreate-buttons">
            <Button type="submit">Submit</Button>
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
      )}
      <h3 className="allaroundred">Must enter at least 3 char and less than 32 char</h3>
    </>
  );
};
