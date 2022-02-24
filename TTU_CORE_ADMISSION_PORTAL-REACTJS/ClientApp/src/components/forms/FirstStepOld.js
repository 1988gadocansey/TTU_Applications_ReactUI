import React from "react";
import ReactDOM from "react-dom";
import { Form, Input, Button, Select, Row, Col } from "antd";
const { Option } = Select;

const FirstStep = () => {
    const [form] = Form.useForm();

    const onGenderChange = (value) => {
        switch (value) {
            case "male":
                form.setFieldsValue({
                    note: "Hi, man!"
                });
                return;

            case "female":
                form.setFieldsValue({
                    note: "Hi, lady!"
                });
                return;

            case "other":
                form.setFieldsValue({
                    note: "Hi there!"
                });
                return;
        }
    };

    const onFinish = (values) => {
        console.log(values);
    };

    const onReset = () => {
        form.resetFields();
    };

    const onFill = () => {
        form.setFieldsValue({
            note: "Hello world!",
            gender: "male"
        });
    };

    return (
        <div>
            <p></p>
            <div>
                <Form name='step1' form={form}>
                    <Row>
                        <Col sm={8}>
                            <Form.Item label="Last Name" name="LastName"  rules={[{ required: true }]}>
                                <Input   placeholder="Last Name" />
                            </Form.Item>
                        </Col>
                        <Col sm={{ offset: 1, span: 8 }} >
                            <Form.Item label="First Name" name="FirstName" rules={[{ required: true }]}>
                                <Input placeholder="First Name" />
                            </Form.Item>
                            
                        </Col>
                        <Col sm={{ offset: 2, span: 5 }}>
                            <Form.Item label="Other Names" name="OtherNames">
                                <Input placeholder="Other Names" />
                            </Form.Item>

                        </Col>
                        
                    </Row>
                    
                    
                    <Row>
                        <Col sm={{ offset: 0, span: 6 }}>
                            <Form.Item
                                name="Gender"
                                label="Gender"
                                rules={[{ required: true }]}
                            >
                                <Select placeholder="Select Tile" allowClear>
                                    <Option value="Male">Male</Option>
                                    <Option value="Female">Female</Option>
                                </Select>
                            </Form.Item>
                        </Col>
                        <Col sm={{ offset: 4, span: 6 }}>
                            <Form.Item
                                name="Title"
                                label="Title"
                                rules={[{ required: true }]}>
                                <Select placeholder="Select Title" allowClear>
                                    <Option value="Mr">Mr</Option>
                                    <Option value="Ms">Ms</Option>
                                    <Option value="Mrs">Mrs</Option>
                                    <Option value="Miss">Miss</Option>
                                    <Option value="Dr">Dr</Option>
                                    <Option value="Prof">Prof</Option>
                                    <Option value="Esq">Lawyer</Option>
                                    <Option value="Rev">Rev</Option>
                                </Select>
                            </Form.Item>
                        </Col>
                        <Col sm={{ offset: 2, span: 6 }}>
                            <Form.Item
                                name="MaritalStatus"
                                label="Marital Status"
                                rules={[{ required: true }]}
                            >
                                <Select placeholder="Select Status" allowClear>
                                    <Option value="Mr">Mr</Option>
                                    <Option value="Ms">Ms</Option>
                                    <Option value="Mrs">Mrs</Option>
                                    <Option value="Miss">Miss</Option>
                                    <Option value="Dr">Dr</Option>
                                    <Option value="Prof">Prof</Option>
                                    <Option value="Esq">Lawyer</Option>
                                    <Option value="Rev">Rev</Option>
                                </Select>
                            </Form.Item>
                        </Col>
                        
                    </Row>
                </Form>
            </div>
        </div>
    );
};

export  default FirstStep