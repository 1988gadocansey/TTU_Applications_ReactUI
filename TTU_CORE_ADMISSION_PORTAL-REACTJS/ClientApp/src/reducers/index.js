import {combineReducers} from "redux";
import userReducer from "./UserReducer";
import avatarReducer from "./AvatarReducer";
const reducers = combineReducers({

    people: userReducer,
    photo:avatarReducer

})

export default reducers
