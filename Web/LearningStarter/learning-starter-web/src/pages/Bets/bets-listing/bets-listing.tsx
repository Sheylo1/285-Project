import axios from "axios";
import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Button, Header, Segment, Table } from "semantic-ui-react";
import { ApiResponse, BetGetDto } from "../../../constants/types";
import { routes } from "../../../routes/config";

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
          <Header>Bets</Header>
          <Button type="button" onClick={() => history.push(routes.betCreate)}>
            + Create Bet
          </Button>
          <Table>
            <Table.Header>
              <Table.Row>
                <Table.HeaderCell>Id</Table.HeaderCell>
                <Table.HeaderCell>Join Bet</Table.HeaderCell>
                <Table.HeaderCell>Name</Table.HeaderCell>
                <Table.HeaderCell>Bet CategoryId</Table.HeaderCell>
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
                        type="button"
                        onClick={() => history.push(routes.betUpdate.replace(":id", `${bet.id}`))}
                      >
                        Edit Bet
                      </Button>
                      {bet.id}
                    </Table.Cell>
                    <Table.Cell>
                      <Button
                        type="button"
                        onClick={() => history.push(routes.betCreate)}
                      >
                        Join Bet
                      </Button>
                    </Table.Cell>
                    <Table.Cell>{bet.name}</Table.Cell>
                    <Table.Cell>{bet.betCategoryId}</Table.Cell>
                    <Table.Cell>{bet.createdDate}</Table.Cell>
                    <Table.Cell>{bet.betDisputeCall}</Table.Cell>
                    <Table.Cell><Button
                        type="button"
                        onClick={() => history.push(routes.betDelete.replace(":id", `${bet.id}`))}
                      >
                        Delete
                      </Button></Table.Cell>
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
