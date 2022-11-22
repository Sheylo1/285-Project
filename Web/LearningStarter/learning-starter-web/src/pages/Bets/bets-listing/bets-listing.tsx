import axios from "axios";
import moment from "moment";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Button, Header, Segment, Table } from "semantic-ui-react";
import { ApiResponse, BetGetDto } from "../../../constants/types";
import { routes } from "../../../routes/config";
import "./bets-listing.css";

export const BetsListingPage = () => {
  const [bets, setBets] = useState<BetGetDto[]>();
  const history = useHistory();
  useEffect(() => {
    const fetchBets = async () => {
      const response = await axios.get<ApiResponse<BetGetDto[]>>("api/bet");
      if (response.data.hasErrors) {
        alert("something went wrong for some reason idk.");
        return;
      }
      setBets(response.data.data);
    };

    fetchBets();
  }, []);

  return (
    <>
      {bets && (
        <Segment>
          <h1 className="bottom-header">Bets</h1>
          <div className="betslisting-buttons">
          <Button type="button" color="green" onClick={() => history.push(routes.betCreate)}>
            + Create Bet
          </Button>
          </div>
          <Table celled>
            <Table.Header>
              <Table.Row>
                <Table.HeaderCell>Id</Table.HeaderCell>
                <Table.HeaderCell>Join Bet</Table.HeaderCell>
                <Table.HeaderCell>Name</Table.HeaderCell>
                <Table.HeaderCell>Bet Category Id</Table.HeaderCell>
                <Table.HeaderCell>Created Date</Table.HeaderCell>
                <Table.HeaderCell>Dispute Status</Table.HeaderCell>
                <Table.HeaderCell>Delete Bet</Table.HeaderCell>
              </Table.Row>
            </Table.Header>
            <Table.Body>
              {bets.map((bet) => {
                return (
                  <Table.Row>
                    <Table.Cell>
                      <Button
                        type="button" color="yellow"
                        onClick={() =>
                          history.push(
                            routes.betUpdate.replace(":id", `${bet.id}`)
                          )
                        }
                      >
                        Edit Bet #{bet.id}
                      </Button>
                    </Table.Cell>
                    <Table.Cell>
                      <Button
                        type="button" color="blue"
                        onClick={() => history.push(routes.bet)}
                      >
                        Join Bet
                      </Button>
                    </Table.Cell>
                    <Table.Cell>{bet.name}</Table.Cell>
                    <Table.Cell>{bet.betCategoryId}</Table.Cell>
                    <Table.Cell>{moment(bet.createdDate)
                    .format("MMMM Do YYYY")
                    .toString()}</Table.Cell>
                    <Table.Cell>{bet.betDisputeCall.toString()}</Table.Cell>
                    <Table.Cell>
                      <Button
                        type="button" color="red"
                        onClick={() =>
                          history.push(
                            routes.betDelete.replace(":id", `${bet.id}`)
                          )
                        }
                      >
                        Delete
                      </Button>
                    </Table.Cell>
                  </Table.Row>
                );
              })}
            </Table.Body>
          </Table>
        </Segment>
      )}
    </>
  );
};
