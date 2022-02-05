import {useDispatch, useSelector} from "react-redux";
import authService from "../api-authorization/AuthorizeService";
import {geLoggedInUser} from "../../actions/user/UsersAction"
import {useEffect} from "react";
import Store from "../../utils/Store";
const Form =()=>{
    
    const users =useSelector((state) => state);
     
    /*const users =useSelector((state) => state);
    const dispatch=useDispatch();
    const fetchProducts = async () => {
        await authService.getUser().then((res) => {
            dispatch( geLoggedInUser(JSON.stringify(res)))
        })
    }
    useEffect(() =>{
        fetchProducts()
    },[])*/
     const activeRoles = () => {
        const state = Store.getState()
        console.log(state)
        return state.people.loggedInUser
    }
    useEffect(() =>{
        activeRoles()
    },[])
     
    /*const userData = users.map((user) =>{
      const{name,email} = user
        return(
            <div>
                <p>{name}</p>
                <p>{email}</p>
            </div>
        )
    })*/
    return(
        <div>
             <div className="site-layout-background">

                <p>sss</p>
            </div> 
        </div>
    )
}
export default Form
