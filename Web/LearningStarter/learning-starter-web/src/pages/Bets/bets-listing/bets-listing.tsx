import axios from "axios";
import React, { useEffect, useState } from "react";
import { Header, Segment, Table } from "semantic-ui-react";
import { ApiResponse, BetGetDto } from "../../../constants/types";

export const BetsListingPage = () => {
  const [bets, setBets] = useState<BetGetDto[]>();
  
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
            <Table>
              <Table.Header>
                <Table.Row>
                <Table.HeaderCell>Id</Table.HeaderCell>
                <Table.HeaderCell>Name</Table.HeaderCell>
                <Table.HeaderCell>Created Date</Table.HeaderCell>
                </Table.Row>
              </Table.Header>
              <Table.Body>
                {bets.map((bet) => {
                  return (
                    <Table.Row>
                      <Table.Cell>{bet.id}</Table.Cell>
                      <Table.Cell>{bet.name}</Table.Cell>
                      <Table.Cell>{bet.createdDate}</Table.Cell>
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
