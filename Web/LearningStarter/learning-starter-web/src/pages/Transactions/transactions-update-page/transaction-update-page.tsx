import React from "react";
import { Field, Form, Formik } from "formik";
import { Input, Button } from "semantic-ui-react";
import { useHistory, useRouteMatch } from "react-router-dom";
import { routes } from "../../../routes/config";
import { ApiResponse,TransactionGetDto, TransactionUpdateDto,} from "../../../constants/types";
import axios from "axios";
import "./transaction-update-page.css";


 
export const TransactionUpdatePage = () => {
  let match = useRouteMatch<{ id: string }>();
  const id = match.params.id;
 
  const initialValues: TransactionUpdateDto = {
    amount: 0,
    paymentType: "",
    createdAt: new Date,
  };
  const history = useHistory();
  const onSubmit = async (values: TransactionUpdateDto) => {
    values = {
      amount: Number(values.amount),
      paymentType: String(values.paymentType),
      createdAt: new Date(values.createdAt),
    };
 
    const response = await axios.put<ApiResponse<TransactionGetDto>>(
      `/api/transactions/${id}`,
      values
    );
 
    if (response.data.hasErrors) {
      alert("Something went wrong.");
      return;
    } else {
      alert("Nothing went wrong!");
      history.push(routes.transaction);
    }
  };
 
  return (
    <>
    <h2 className="transactioncreate-header">Edit New Transaction</h2>
  <Formik onSubmit={onSubmit} initialValues={initialValues }>
    <Form>
      <div>
        <div>
        <div>
        <div className="transactionupdate1-header">
            <label htmlFor="amount">Amount</label>
          </div>
          <div className="transactioncreate1-header">
          <Field className="field" id="amount" name="amount">
            {({ field }) => <Input placeholder="$" {...field} />}
          </Field>
          </div>
        </div>
        <div className="transactionupdate1-header">
        <label htmlFor="payment">PaymentType</label>
        </div>
        <div className="transactionupdate1-header">
        <Field className="field" id="paymentType" name="paymentType">
            {({ field }) => <Input placeholder="PaymentType" {...field} />}
          </Field>
        </div>
        </div>
      </div>
      <div>
        <div className="transactionupdate-buttons">
        <Button
          primary
          type="submit"
        >
          Submit
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
