import { connect } from 'react-redux'
import PrintPreview from '../components/print/PrintPreview'

const mapStateToProps = (state) => ({
    applicantData: state.applicant.applicantInfo
})

export default connect(mapStateToProps)(PrintPreview)
