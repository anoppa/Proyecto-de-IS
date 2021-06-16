import "./App.css";
import { Component } from "react";
import { Route, Switch } from "react-router";
import { BrowserRouter } from "react-router-dom";
import Layout from "../../components/Layout/Layout";
import Home from "../../components/Home/Home";
import Login from "../../components/Login/Login";
import Register from "../../components/Register/Register";
import Reserve from "../../components/Reserve/Reserve";
import FilmScreenings from "../../components/FilmScreenings/FilmScreenings";
import MoviesScreening from "../../components/MoviesScreening/MoviesScreening";
import Films from "../../components/Films/Films";
import FilmForm from "../../components/FilmForm/FilmForm";
import FilmScreeningForm from "../../components/FilmScreeningForm/FilmScreeningForm";
import Top10Form from "../../components/Top10Form/Top10Form";
import PurchaseOrder from "../../components/PurchaseOrder/PurchaseOrder";
import MyReservations from "../../components/MyReservations/MyReservations";
import ClubMemberForm from "../../components/ClubMemberForm/ClubMemberForm";
import BookEntry from "../../components/BookEntry/BookEntry";
import WebMaster from "../../components/WebMaster/WebMaster";
import Payment from "../../components/Payment/Payment";

class App extends Component {
  logginUserCallback = (
    email,
    password,
    roles,
    jwt_token,
    id,
    username,
    isMember
  ) => {
    localStorage.setItem(
      "loggedUser",
      JSON.stringify({
        email: email,
        password: password,
        roles: roles,
        userId: id,
        unsername: username,
        jwt_token: jwt_token,
        isClubMember: isMember,
      })
    );
  };

  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route
              path="/login"
              component={(props) => (
                <Login {...props} onLoginCallback={this.logginUserCallback} />
              )}
            />
            <Route path="/register" component={Register} />
            <Route path="/reserve" component={Reserve} />
            <Route path="/myReservations" component={MyReservations} />
            <Route path="/filmScreenings" component={FilmScreenings} />
            <Route path="/movieScreenings" component={MoviesScreening} />
            <Route path="/films" component={Films} />
            <Route path="/filmForm" component={FilmForm} />
            <Route path="/filmScreeningForm" component={FilmScreeningForm} />
            <Route path="/top10Form" component={Top10Form} />
            <Route path="/purchaseOrder" component={PurchaseOrder} />
            <Route path="/clubMemberForm" component={ClubMemberForm} />
            <Route path="/bookEntry" component={BookEntry} />
            <Route path="/webMaster" component={WebMaster} />
            <Route path="/payment" component={Payment} />
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}

export default App;
