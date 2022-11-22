import React from "react";
import { Field, Form, Formik } from "formik";
import { Input, Button } from "semantic-ui-react";
import {useHistory} from 'react-router-dom'
import { routes } from "../../../routes/config";
import { ApiResponse, TransactionCreateDto, TransactionGetDto } from "../../../constants/types";
import axios from "axios";
import "./transaction-create-page.css";

 
export const TransactionCreatePage = () => {
    const initialValues: TransactionCreateDto = {
        amount: 0,
        paymentType: "",
        createdAt: new Date,
    };
    const history = useHistory();
    const onSubmit = async (values: TransactionCreateDto) => {
 
      values = {
          amount: Number(values.amount),
          paymentType: String(values.paymentType),
          createdAt: new Date(values.createdAt),
      }
 
      const response = await axios.post<ApiResponse<TransactionGetDto>>(
        "/api/transactions",
        values
      );
 
      if (response.data.hasErrors) {
        alert("Something went wrong.");
        return;
      }else{
              alert("Nothing went wrong!");
       history.push(routes.transaction);
      }
   
    };
    return (
        <>
        <h2 className="transactioncreate-header">Add New Transaction</h2>
      <Formik onSubmit={onSubmit} initialValues={initialValues }>
        <Form>
          <div>
            <div>
            <div>
            <div className="transactioncreate1-header">
                <label htmlFor="amount">Amount</label>
              </div>
              <div className="transactioncreate1-header">
              <Field className="field" id="amount" name="amount">
                {({ field }) => <Input placeholder="$" {...field} />}
              </Field>
              </div>
            </div>
            <div className="transactioncreate1-header">
            <label htmlFor="payment">PaymentType</label>
            </div>
            <div className="transactioncreate1-header">
            <Field className="field" id="paymentType" name="paymentType">
                {({ field }) => <Input placeholder="PaymentType" {...field} />}
              </Field>
            </div>
            </div>
          </div>
          <div>
            <div className="transactioncreate-buttons">
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
