import { Field, Form, Formik } from "formik";
import React from "react";
import { Button,Input } from "semantic-ui-react";
import { useHistory } from "react-router-dom";
import { routes } from "../../../routes/config";
import {ApiResponse,HouseSystemCreateDto,HouseSystemGetDto,} from "../../../constants/types";
import axios from "axios";
import "./houseSystem-create-page.css";

export const HouseSystemCreatePage = () => {
  const initialValues: HouseSystemCreateDto = {
      betPercentage: 0,
      payout: 0,
  };
  const history = useHistory();
  const onSubmit = async (values: HouseSystemCreateDto) => {

    values = {
        betPercentage: Number(values.betPercentage),
        payout: Number(values.payout),
    }

    const response = await axios.post<ApiResponse<HouseSystemGetDto>>(
      "/api/house-systems",
      values
    );

    if (response.data.hasErrors) {
      alert("Something went wrong.");
      return;
    }else{
     history.push(routes.housesystem);
    }


  };
  return (
    <>
      <h2 className="houseSystemcreate-header">Add New House System</h2>
      <Formik onSubmit={onSubmit} initialValues={initialValues }>
        <Form>
          <div>
            <div>
            <div>
            <div className="houseSystemcreate1-header">
                <label htmlFor="Bet Percentage">Bet Percentage</label>
              </div>
              <div className="houseSystemcreate1-header">
              <Field className="field" id= "betPercentage" name="betPercentage">
                {({ field }) => <Input placeholder="%" {...field} />}
              </Field>
              </div>
            </div>
            <div className="houseSystemcreate1-header">
            <label htmlFor="name">Payout</label>
            </div>
            <div className="houseSystemcreate1-header">
            <Field className="field" id="payout" name="payout">
                {({ field }) => <Input placeholder="$" {...field} />}
              </Field>
            </div>
            </div>
          </div>
          <div>
            <div className="houseSystemcreate-buttons">
            <Button
              primary
              type="submit"
            >
              Submit
            </Button>
            <Button
              secondary
              type="button"
               onClick={() => history.push(routes.housesystem)}
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