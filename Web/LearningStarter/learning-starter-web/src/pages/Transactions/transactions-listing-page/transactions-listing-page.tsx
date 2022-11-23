import axios from "axios";
import React from "react";
import { Button, Icon, Segment, Table } from "semantic-ui-react";
import Header from "semantic-ui-react/dist/commonjs/elements/Header/Header";
import { ApiResponse, TransactionGetDto } from "../../../constants/types";
import {useHistory} from 'react-router-dom'
import { routes } from "../../../routes/config";
import moment from "moment";
import "./transactions-listing-page.css";

export const TransactionListingPage = () => {
  const [Transaction, setTransaction] = React.useState<TransactionGetDto[]>();
    const history = useHistory()
  console.log(Transaction);
  React.useEffect(() => {
    const fetchTransaction = async () => {
      const response = await axios.get<ApiResponse<TransactionGetDto[]>>(
        "api/transactions"
      );
      if (response.data.hasErrors) {
        alert("Something went wrong.");
        return;
      }

      setTransaction(response.data.data);
    };

    fetchTransaction();
  }, []);
  return (
    <>
      {Transaction && (
        <Segment>
          <h1 className="bottom-header">Transactions</h1>{" "}
          <div className='button'>
          <Button color= 'green' onClick={() => history.push(routes.transactionCreate)}>
            + Create
          </Button>
          </div> 
          <Table celled>
            {" "}
            <Table.Header>
              <Table.Row>
                {" "}
                <Table.HeaderCell>Edit</Table.HeaderCell>
                <Table.HeaderCell>Delete</Table.HeaderCell>
                <Table.HeaderCell>Payment Type</Table.HeaderCell>
                <Table.HeaderCell>Amount</Table.HeaderCell>
                <Table.HeaderCell>Transaction Date</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {Transaction.map(Transaction => {
                 return (
                <React.Fragment key={Transaction.id}>
                  <Table.Row>
                  <Table.Cell><Icon className="clickable" name='edit' onClick={() => history.push(`/transaction/${Transaction.id}`)}/></Table.Cell> 
                  <Table.Cell><Icon className="clickable" name='delete' onClick= {() => history.push(`/transaction/delete/${Transaction.id}`)}/></Table.Cell>
                    <Table.Cell>{Transaction.paymentType}</Table.Cell>
                    <Table.Cell>${Transaction.amount}</Table.Cell>
                    <Table.Cell>{moment(Transaction.createdAt).format("MMMM Do YYYY")}</Table.Cell>
                  </Table.Row>
                </React.Fragment>
                 );
                 })}
            </Table.Body>
          </Table>
          <div className = "button">
            <Button color= 'blue' onClick={() => history.push(routes.home)}>
            Go Home
          </Button>
          </div>
        </Segment>
      )}
    </>
  );
};