import {combineReducers} from "redux";
import userReducer from "./UserReducer";
const reducers = combineReducers({

    people: userReducer

})

export default reducers
