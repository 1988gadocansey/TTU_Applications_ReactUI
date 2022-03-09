import React, { useRef } from 'react'
import PropTypes from 'prop-types'
import ReactToPrint from 'react-to-print'
import { Avatar, Typography } from 'antd'
import { getAge } from '../../utils/nationalities'
import parse from 'html-react-parser'
import { PrinterOutlined } from '@ant-design/icons'
const { Title, Text } = Typography
const PrintPreview = (props) => {
    const componentRef = useRef()

    return (
        <div>
            <ReactToPrint
                trigger={() => <PrinterOutlined type={'button'} title={'Print'} />}
                content={() => componentRef.current}
            />
            <div style={{ display: 'none2', marginTop: 20 }}>
                <div className="ant-card">
                    <div className="ant-card-body">
                <div ref={componentRef} style={{ display: 'block' }}>
                    <div style={{ marginTop: 20 }}>
                        {/* <div style={{ colorAdjust: 'exact', WebkitPrintColorAdjust: 'exact', margin: '10px 0px', background: '#1a337e', height: '1px' }}>&nbsp;</div> */}
                        <table align={'center'} width={'80%'}>
                            <tbody className="ant-table-tbody">
                            <tr>
                                <td colSpan="3" align={'center'}>
                                    <Avatar
                                        size={100}
                                        src={'/images/ttuLogo.png'}
                                    />
                                    <Avatar
                                        size={100}
                                        src={'/images/ttuLogo.png'}
                                    />
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" align={'center'}>
                                    <div style={{ justifyContent: 'center', alignContent: 'center', display: 'flex', alignItems: 'center' }}>
                                        <div align={'center'}>
                                            <Title style={{ fontWeight: 'normal', marginBottom: -10 }} level={4}>
                                                SRC NOMINATION FORM 2020/2021
                                            </Title>
                                            <Title style={{ fontWeight: 'normal', lineHeight: 0, marginBottom: -10 }} level={4}>
                                                FORM A
                                            </Title>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" align={'center'}>
                                    <Title style={{ fontWeight: 'normal' }} level={4}>
                                        PARTICULARS OF ASPIRANT
                                    </Title>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" align={'center'}>
                                    <Avatar
                                        shape={'square'}
                                        size={150}
                                        src={props.applicantData.file}
                                    />
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>Name of aspirant:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.name}</Text>
                                </td>
                                <td align={'left'}>
                                    <Text className={'printTextTitle'}>date of birth:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.dateOfBirth}</Text>
                                </td>
                            </tr>
                            <tr>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>age:&nbsp;</Text>
                                    <Text className={'printText'}>{getAge(props.applicantData.dateOfBirth)}</Text>
                                </td>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>gender:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.gender}</Text>
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>place of birth:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.placeOfBirth}</Text>
                                </td>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>nationality:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.nationality}</Text>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" className="">
                                    <Text className={'printTextTitle'}>home address:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.homeAddress}</Text>
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>Hometown:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.homeTown}</Text>
                                </td>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>region:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.region}</Text>
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>telephone:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.telephone}</Text>
                                </td>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>email:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.email}</Text>
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>faculty:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.faculty}</Text>
                                </td>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>programme:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.programme}</Text>
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>cgpa:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.cgpa}</Text>
                                </td>
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>index number:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.indexNumber}</Text>
                                </td>
                            </tr>
                            <tr>

                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>year:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.year}</Text>
                                </td>
                                <td>
                                    <Text className={'printTextTitle'}>hall of residence or affiliation:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.hall}</Text>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" className="">
                                    <Text className={'printTextTitle'}>position applying for:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.name}</Text>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" className="">
                                    <Text className={'printTextTitle'}>previous Post(s) held in ttu:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.previousPosition}</Text>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" className="">
                                    <Text className={'printTextTitle'}>former Institution:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.formerInstitution}</Text>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" className="">
                                    <Text className={'printTextTitle'}>Position(s) held in former Institution:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.formerPosition}</Text>
                                </td>
                            </tr>
                            <tr >
                                <td colSpan="3" align={'left'}>
                                    <Text className={'printTextTitle'}>signature of applicat:&nbsp;</Text>
                                    <Text className={'printText'}>.............................................</Text>
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" align={'left'}>
                                    <Text className={'printTextTitle'}>date:&nbsp;</Text>
                                    <Text className={'printText'}>{new Date().toDateString()}</Text>
                                </td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style={{ marginTop: 20 }}>
                        {/* <div style={{ colorAdjust: 'exact', WebkitPrintColorAdjust: 'exact', margin: '10px 0px', background: '#1a337e', height: '1px' }}>&nbsp;</div> */}
                        <table align={'center'} width={'80%'}>
                            <tbody className="ant-table-tbody">
                            <tr>
                                <td colSpan="3" align={'center'}>
                                    <Avatar
                                        size={100}
                                        src={'/images/ttuLogo.png'}
                                    />
                                    <Avatar
                                        size={100}
                                        src={'/images/ttuLogo.png'}
                                    />
                                </td>
                            </tr>
                            <tr>
                                <td colSpan="3" align={'center'}>
                                    <div style={{ justifyContent: 'center', alignContent: 'center', display: 'flex', alignItems: 'center' }}>
                                        <div align={'center'}>
                                            <Title style={{ fontWeight: 'normal', marginBottom: -10 }} level={4}>
                                                SRC NOMINATION FORM 2020/2021
                                            </Title>
                                            <Title style={{ fontWeight: 'normal', lineHeight: 0, marginBottom: -10 }} level={4}>
                                                FORM A
                                            </Title>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr >
                                <td className="" align={'left'}>
                                    <Text className={'printTextTitle'}>Name of aspirant:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.name}</Text>
                                </td>
                                <td align={'left'}>
                                    <Text className={'printTextTitle'}>date of birth:&nbsp;</Text>
                                    <Text className={'printText'}>{props.applicantData.dateOfBirth}</Text>
                                </td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                    {
                        props.applicantData.statementOfPurpose !== null &&
                        <>
                            <div className="page-break"/>
                            <div style={{ padding: 100 }}>
                                <div align={'center'}>
                                    <Title className={'printTextTitle'} level={3}>
                                        statement of purpose
                                    </Title>
                                </div>
                                <div style={{ width: '100%' }}>
                                    {/*{parse(props.applicantData.statementOfPurpose)}*/}
                                </div>
                            </div>
                        </>
                    }

                    {
                        props.applicantData.vision !== null &&
                        <>
                            <div className="page-break"/>
                            <div style={{ padding: 100 }}>
                                <div align={'center'}>
                                    <Title className={'printTextTitle'} level={3}>
                                        vision statement
                                    </Title>
                                </div>
                                <div style={{ width: '100%' }}>
                                    {/*{parse(props.applicantData.vision)}*/}
                                </div>
                            </div>
                        </>
                    }
                    {
                        props.applicantData.mission !== null &&
                        <>
                            <div className="page-break"/>
                            <div style={{ padding: 100 }}>
                                <div align={'center'}>
                                    <Title className={'printTextTitle'} level={3}>
                                        mission statement
                                    </Title>
                                </div>
                                <div style={{ width: '100%' }}>
                                    {/*{parse(props.applicantData.mission)}*/}
                                </div>
                            </div>
                        </>
                    }
                    {
                        props.applicantData.planOfAction !== null &&
                        <>
                            <div className="page-break"/>
                            <div style={{ padding: 100 }}>
                                <div align={'center'}>
                                    <Title className={'printTextTitle'} level={3}>
                                        plan Of Action
                                    </Title>
                                </div>
                                <div style={{ width: '100%' }}>
                                    {/*{parse(props.applicantData.planOfAction)}*/}
                                </div>
                            </div>
                        </>
                    }
                </div>
            </div>
        </div>
            </div>
        </div>
        
    )
}
export default PrintPreview

PrintPreview.propTypes = {
    applicantData: PropTypes.object.isRequired
}
