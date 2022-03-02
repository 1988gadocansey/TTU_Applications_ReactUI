import { Types } from './Types'
import API from "../../utils/api";
export const  getProgrammes = (dispatch,programmes) => async () => {
    await API.get('/SelectBoxController/getProgrammes')
        .then((res) => {
            dispatch({
                type: Types.GET_PROGRAMME,
                payload: programmes
            })

        }).catch((err) => {
            console.log("error",err)
        })

}
 