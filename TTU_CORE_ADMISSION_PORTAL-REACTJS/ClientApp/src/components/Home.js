import React, {Component, useEffect} from "react";
import Dashboard from "./dashboard/Dashboard";
import {useDispatch, useSelector} from "react-redux";
import authService from "./api-authorization/AuthorizeService";
import {geLoggedInUser} from "../actions/user/UsersAction";
 
 const Home = () => {
 
   
    return(
        <>
         
        <Dashboard/>
            </>
    )

};

export default Home