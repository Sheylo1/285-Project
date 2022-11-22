import { Field, Form, Formik } from "formik";
import React from "react";
import { Button,Input } from "semantic-ui-react";
import { useHistory, useRouteMatch} from "react-router-dom";
import { routes } from "../../../routes/config";
import "./houseSystem-update-page.css";
import { ApiResponse, HouseSystemGetDto, HouseSystemUpdateDto,} from "../../../constants/types";
import axios from "axios";

export const HouseSystemUpdatePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;

  const initialValues: HouseSystemUpdateDto = {
    payout: 0,
   betPercentage: 0,
  };
  const history = useHistory();
  const onSubmit = async (values: HouseSystemUpdateDto) => {
    values = {
    betPercentage: Number(values.betPercentage),
    payout: Number(values.payout),
    };

    const response = await axios.put<ApiResponse<HouseSystemGetDto>>(
      `/api/house-systems/${id}`,
      values
    );

    if (response.data.hasErrors) {
      alert("Something went wrong.");
      return;
    } else {
      alert("Nothing went wrong!");
      history.push(routes.housesystem);
    }
  };
return (
    <>
      <h2 className="houseSystemcreate-header"> Edit House System</h2>
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