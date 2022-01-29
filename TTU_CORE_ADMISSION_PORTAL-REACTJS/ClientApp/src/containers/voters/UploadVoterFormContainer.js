import { connect } from 'react-redux'
import { getAllGroups, getGroupElections } from '../../actions/group/GroupAction'
import UploadVoterForm from '../../components/voters/upload-voter-form'

const mapStateToProps = (state) => ({
  groups: state.groupReducer.groups,
  groupElections: state.groupReducer.groupElections,
})

const mapDispatchToProps = (dispatch) => ({
  getAllGroups: () => getAllGroups(),
  getGroupElections: (payload) => dispatch(getGroupElections(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(UploadVoterForm)
