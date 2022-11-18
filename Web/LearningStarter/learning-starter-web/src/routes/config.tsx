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
