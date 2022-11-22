import React from "react";
import { Route, Switch, Redirect } from "react-router-dom";
import { LandingPage } from "../pages/landing-page/landing-page";
import { NotFoundPage } from "../pages/not-found";
import { useUser } from "../authentication/use-auth";
import { UserPage } from "../pages/user-page/user-page";
import { PageWrapper } from "../components/page-wrapper/page-wrapper";
import { BetCategoriesListingPage } from "../pages/BetCategories/betCategory-listing-page/betCategory-listing";
import { BetCategoriesCreatePage } from "../pages/BetCategories/betCategory-create-page/betCategory-create";
import { BetCategoriesUpdatePage } from "../pages/BetCategories/betCategory-update-page/betCategory-update";
import { BetCategoriesDeletePage } from "../pages/BetCategories/betCategory-delete-page/betCategory-delete";
import { BetsListingPage } from "../pages/Bets/bets-listing/bets-listing";
import { BetsCreatePage } from "../pages/Bets/bet-create-page/bet-create-page";
import { BetUpdatePagePage } from "../pages/Bets/bet-update-page/bet-update-page";
import { BetDeletePage } from "../pages/Bets/bet-delete-page/bet-delete-page";
import { CommentsListingPage } from "../pages/comments/comments-listing/comments-listing";
import { CommentsCreatePage } from "../pages/comments/comments-create/comments-create";
import { CommentsUpdatePage } from "../pages/comments/comments-update/comments-update";
import { CommentsDeletePage } from "../pages/comments/comments-delete/comments-delete";
import { EmployeesListingPage } from "../pages/employees/employees-listing/employees-listing";
import { EmployeesCreatePage } from "../pages/employees/employee-create-page/employee-create-page";
import { EmployeesUpdatePage } from "../pages/employees/employee-update-page/employee-update-page";
import { HouseSystemCreatePage } from "../pages/HouseSystem/houseSystem-create-page/houseSystem-create-page";
import { HouseSystemListingPage } from "../pages/HouseSystem/houseSystem-listing-page/houseSystem-listing-page";
import { HouseSystemDeletePage } from "../pages/HouseSystem/houseSystem-delete-page/houseSystem-delete-page";
import { HouseSystemUpdatePage } from "../pages/HouseSystem/houseSystem-update-page/houseSystem-update-page";
import { TransactionListingPage } from "../pages/Transactions/transactions-listing-page/transactions-listing-page";
import { TransactionDeletePage } from "../pages/Transactions/transactions-delete-page/transactions-delete-page";
import { TransactionCreatePage } from "../pages/Transactions/transactions-create-page/transactions-create-page";
import { TransactionUpdatePage } from "../pages/Transactions/transactions-update-page/transaction-update-page";

//This is where you will declare all of your routes (the ones that show up in the search bar)
export const routes = {
  root: `/`,
  home: `/home`,
  user: `/user`,
  betCategories: {
    listing: "/betcategorylisting",
    create: "/betcategorycreate",
    update: "/betcategoryupdate/:id",
    delete: "/betcategorydelete/:id",
  },
  bet: `/bets`,
  betCreate: `/bets/create`,
  betUpdate: `/bets/:id`,
  betDelete: `/bets/delete/:id`,
  users: `/users`,
  usercreate: `/user/create`,

  comment: `/comment`,
  commentsCreate: `/comment/create`,
  commentsUpdate: `/comment/:id`,
  commentsDelete: `/comment/delete/:id`,

  employees: `/employees`,
  employeescreate: `/employees/create`,
  employeesupdate: `/employees/:id`,

  transaction:`/transaction`,
  transactionDelete: `/transaction/delete/:id`,
  transactionUpdate: `/transaction/:id`,
  transactionCreate: `/transaction/create`,

  housesystem: `/houseSystem`,
  housesystemCreate: `/houseSystem/create`,
  housesystemDelete:  `/houseSystem/delete/:id`,
  housesystemUpdate: `/houseSystem/:id`,
};

//This is where you will tell React Router what to render when the path matches the route specified.
export const Routes = () => {
  //Calling the useUser() from the use-auth.tsx in order to get user information
  const user = useUser();
  return (
    <>
      {/* The page wrapper is what shows the NavBar at the top, it is around all pages inside of here. */}
      <PageWrapper user={user}>
        <Switch>
          {/* When path === / render LandingPage */}
          <Route path={routes.home} exact>
            <LandingPage />
          </Route>
          {/* When path === /iser render UserPage */}
          <Route path={routes.user} exact>
            <UserPage />
          </Route>
          <Route path={routes.betCategories.create} exact>
            <BetCategoriesCreatePage />
          </Route>
          <Route path={routes.betCategories.listing} exact>
            <BetCategoriesListingPage />
          </Route>
          <Route path={routes.betCategories.update} exact>
            <BetCategoriesUpdatePage />
          </Route>
          <Route path={routes.betCategories.delete} exact>
            <BetCategoriesDeletePage />
          </Route>
          <Route path={routes.bet} exact>
            <BetsListingPage />
          </Route>
          <Route path={routes.betCreate} exact>
            <BetsCreatePage />
          </Route>
          <Route path={routes.betUpdate} exact>
            <BetUpdatePagePage />
          </Route>
          <Route path={routes.betDelete} exact>
            <BetDeletePage />
            </Route>
          <Route path={routes.comment} exact>
            <CommentsListingPage />
          </Route>
          <Route path={routes.commentsCreate} exact>
            <CommentsCreatePage/>
          </Route>
          <Route path={routes.commentsUpdate} exact>
            <CommentsUpdatePage/>
          </Route>
          <Route path={routes.commentsDelete} exact>
            <CommentsDeletePage/>
          </Route>
          <Route path ={routes.employees} exact>
            <EmployeesListingPage/>
          </Route>
          <Route path={routes.employeescreate} exact>
            <EmployeesCreatePage/>
          </Route>
          <Route path={routes.employeesupdate} exact>
            <EmployeesUpdatePage/>
          </Route>

          <Route path={routes.housesystem} exact>
            <HouseSystemListingPage/>
          </Route>
          <Route path={routes.housesystemCreate} exact>
            <HouseSystemCreatePage/>
          </Route>
          <Route path={routes.housesystemDelete} exact>
            <HouseSystemDeletePage/>
          </Route>
          <Route path={routes.housesystemUpdate} exact>
            <HouseSystemUpdatePage/>
          </Route>

          <Route path={routes.transaction} exact>
            <TransactionListingPage/>
          </Route>
          <Route path={routes.transactionDelete} exact>
            <TransactionDeletePage/>
          </Route>
          <Route path={routes.transactionCreate} exact>
            <TransactionCreatePage/>
          </Route>
          <Route path={routes.transactionUpdate} exact>
            <TransactionUpdatePage/>
          </Route>

          {/* Going to route "localhost:5001/" will go to homepage */}
          <Route path={routes.root} exact>
            <Redirect to={routes.home} />
          </Route>
          {/* This should always come last.  
            If the path has no match, show page not found */}
          <Route path="*" exact>
            <NotFoundPage />
          </Route>
        </Switch>
      </PageWrapper>
    </>
  );
};
