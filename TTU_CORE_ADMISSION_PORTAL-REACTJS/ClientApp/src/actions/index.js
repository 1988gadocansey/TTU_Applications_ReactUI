import axios from "axios";
import {FETCH_USER} from "./types";
const fetchUser = () =>{
 axios.get("https://srms.ttuportal.com/api/student/202011019/fee_type/kkk").then(r => console.log(r.data))
}
