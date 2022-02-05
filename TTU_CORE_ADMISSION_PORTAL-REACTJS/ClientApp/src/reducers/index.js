import {combineReducers} from "redux";
import {persistReducer} from 'redux-persist'
import sessionStorage from 'redux-persist/lib/storage/session'
import userReducer from "./UserReducer";
import resultReducer from "./ResultReducer";
import formReducer from "./FormReducer";
import avatarReducer from "./AvatarReducer";


const reducers = combineReducers({
   
    people: userReducer
    
})

export default reducers
