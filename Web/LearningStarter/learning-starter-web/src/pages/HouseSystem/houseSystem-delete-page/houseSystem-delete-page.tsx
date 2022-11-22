import {Form, Formik } from "formik";
import React from "react";
import {Button } from "semantic-ui-react";
import { useHistory,useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import { ApiResponse,HouseSystemDeleteDto, HouseSystemGetDto,} from "../../../constants/types";
import axios from "axios";

export const HouseSystemDeletePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
  const history = useHistory();

  const onSubmit = async (values: HouseSystemDeleteDto) => {
    const response = await axios.delete<ApiResponse<HouseSystemGetDto>>(
      `/api/house-systems/${id}`
    );

    if (response.data.hasErrors) {
      response.data.errors.forEach((err) => {
        console.log(err.message);
      });
    } else {
      history.push(routes.housesystem);
    }
  };

  return (
    <>
      <h2 className="delete-header">Delete Your House System</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as HouseSystemDeleteDto}>
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