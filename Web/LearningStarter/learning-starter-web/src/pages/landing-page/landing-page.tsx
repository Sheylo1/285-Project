import React, { Component } from "react";
import { Header, Button, Progress } from "semantic-ui-react";
import "./landing-page.css";
import abstract from "../../assets/abstract.png";
import { render } from "@testing-library/react";

//This is a basic Component, and since it is used inside of
//'../../routes/config.tsx' line 31, that also makes it a page
export const LandingPage = () => {
  return (
    <div className="home-page-container">
      <div className="home-items">
        <Header className="header">Coming Soon to Casinos Near You!</Header>
        <img className="abstract-img" src={abstract} width={750} height={500} ></img>
      </div>
    </div>
  );
};