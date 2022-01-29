import { connect } from 'react-redux'
import { setNomineeData } from '../../actions/nominees/NomineesAction'
import PlanOfAction from '../../components/nominees/form/plan-of-action'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(PlanOfAction)
