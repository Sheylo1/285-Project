import axios from "axios";
import { useHistory } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Input } from "semantic-ui-react";
import { ApiResponse, BetGetDto, BetUpdateDto } from "../../../constants/types";
import { useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";

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
      {bets && (
        <Formik initialValues={bets} onSubmit={onSubmit}>
          <Form>
            <div>
              <label htmlFor="name">Name</label>
            </div>
            <Field className="field" id="name" name="name">
              {({ field }) => <Input {...field} />}
            </Field>
            <div>
              <div>
                <label htmlFor="betDisputeCall">Dispute This Bet?</label>
              </div>
              <Field
                className="field"
                id="betDisputeCall"
                name="betDisputeCall"
              >
                {({ field }) => <Input type="boolean" {...field} />}
              </Field>
            </div>
            <Button type="submit">Submit</Button>
          </Form>
        </Formik>
      )}
    </>
  );
};
