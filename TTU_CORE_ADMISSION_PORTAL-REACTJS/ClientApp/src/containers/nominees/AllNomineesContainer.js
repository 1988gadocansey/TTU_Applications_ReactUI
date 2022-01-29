import { connect } from 'react-redux'
import AllNominees from '../../components/nominees/all-nominees'
import { getAllNominees } from '../../actions/nominees/NomineesAction'

const mapStateToProps = (state) => ({
  nominees: state.nominationReducer.nominees
})

const mapDispatchToProps = (dispatch) => ({
  getAllNominees: (payload) => dispatch(getAllNominees(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(AllNominees)
