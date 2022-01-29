import { connect } from 'react-redux'
import { setNomineeData } from '../../actions/nominees/NomineesAction'
import Mission from '../../components/nominees/form/mission'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Mission)
