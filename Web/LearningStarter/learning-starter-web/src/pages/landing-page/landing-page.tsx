import React, { Component } from "react";
import { Header, Button, Progress } from "semantic-ui-react";
import "./landing-page.css";
import GamblingHome from "../../assets/GamblingHome.png";
import { render } from "@testing-library/react";
import TTMG from "../../assets/TTMG.png";

//This is a basic Component, and since it is used inside of
//'../../routes/config.tsx' line 31, that also makes it a page
export const LandingPage = () => {
  return (
    <div className="home-page-container">
      <div className="home-items">
      <img className="ttmg" src={TTMG}></img>
      </div>
    </div>
  );
};