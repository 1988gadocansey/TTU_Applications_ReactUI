import { connect } from 'react-redux'
import { getAllGroups, setGroupData } from '../../actions/group/GroupAction'
import AllGroups from '../../components/groups/all-groups'

const mapStateToProps = (state) => ({
  groups: state.groupReducer.groups
})

const mapDispatchToProps = (dispatch) => ({
  getAllGroups: (payload) => dispatch(getAllGroups(payload)),
  setGroupData: (payload) => dispatch(setGroupData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(AllGroups)
