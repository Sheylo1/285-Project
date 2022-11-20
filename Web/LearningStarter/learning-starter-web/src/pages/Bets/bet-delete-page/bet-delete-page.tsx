import { Field, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Header, Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
import {
  ApiResponse,
  BetDeleteDto,
  BetGetDto,
  BetUpdateDto,
} from "../../../constants/types";
import axios from "axios";
import { useRouteMatch } from "react-router-dom";

export const BetDeletePage = () => {
  const history = useHistory();
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;

  const onSubmit = async (values: BetDeleteDto) => {
    const response = await axios.delete<ApiResponse<BetGetDto>>(
      `/api/bet/${id}`
      //,values
    );

    if (response.data.hasErrors) {
      response.data.errors.forEach((err) => {
        console.log(err.message);
      });
    } else {
      history.push(routes.bet);
    }
  };
  return (
    <>
      <h2 className="delete-header">Delete Your Bet</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as BetDeleteDto}>
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

