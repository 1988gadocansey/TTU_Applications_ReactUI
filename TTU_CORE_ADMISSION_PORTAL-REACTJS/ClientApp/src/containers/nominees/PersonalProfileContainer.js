import { connect } from 'react-redux'
import { setNomineeData } from '../../actions/nominees/NomineesAction'
import PersonalInfo from '../../components/nominees/form/personal-info'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(PersonalInfo)
