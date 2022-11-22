import {Form, Formik } from "formik";
import React from "react";
import {Button } from "semantic-ui-react";
import { useHistory,useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import { ApiResponse,TransactionDeleteDto, TransactionGetDto,} from "../../../constants/types";
import axios from "axios";
 
export const TransactionDeletePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
  const history = useHistory();
 
  const onSubmit = async (values: TransactionDeleteDto) => {
    const response = await axios.delete<ApiResponse<TransactionGetDto>>(
      `/api/transactions/${id}`
    );
 
    if (response.data.hasErrors) {
      response.data.errors.forEach((err) => {
        console.log(err.message);
      });
    } else {
      history.push(routes.transaction);
    }
  };
 
  return (
    <>
      <h2 className="delete-header">Delete Your Transaction</h2>
      <Formik onSubmit={onSubmit} initialValues={{} as TransactionDeleteDto}>
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
                onClick={() => history.push(routes.transaction)}
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
