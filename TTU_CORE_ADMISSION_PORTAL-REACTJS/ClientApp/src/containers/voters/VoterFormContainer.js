import { connect } from 'react-redux'
import VoterForm from '../../components/voters/voter-form'
import { getAllGroups, getGroupElections } from '../../actions/group/GroupAction'

const mapStateToProps = (state) => ({
  groups: state.groupReducer.groups,
  groupElections: state.groupReducer.groupElections,
})

const mapDispatchToProps = (dispatch) => ({
  getGroupElections: (payload) => dispatch(getGroupElections(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(VoterForm)
