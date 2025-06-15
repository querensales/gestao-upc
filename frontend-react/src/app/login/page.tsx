'use client'

import { Button, Col, Form, FormProps, Input, Row } from "antd";
import styles from './page.module.css'
import SigninModel from "@/models/security/signin.model";
import { SecurityService } from "@/services/securityService";


const onFinish: FormProps<SigninModel>['onFinish'] = (values) => {
  SecurityService.signin(values)
};

const onFinishFailed: FormProps<SigninModel>['onFinishFailed'] = (errorInfo) => {
  console.log('Falha:', errorInfo);
};

export default function Autenticacao() {

  return (
    <>
      <Row>
        <Col span={8}></Col>
        <Col span={8}>
          <Form
          className={styles.margem}
            name="basic"
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            style={{ maxWidth: 600 }}
            initialValues={{ remember: true }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
          >
            <Form.Item<SigninModel>
              label="Nome de Usuário"
              name="email"
              rules={[{ required: true, message: 'Preencha o usuário corretamente!' }]}
            >
              <Input />
            </Form.Item>

            <Form.Item<SigninModel>
              label="Senha"
              name="password"
              rules={[{ required: true, message: 'Preencha a senha corretamente!' }]}
            >
              <Input.Password />
            </Form.Item>

            <Form.Item label={null}>
              <Button type="primary" htmlType="submit">
                Entrar
              </Button>
            </Form.Item>
          </Form></Col>
        <Col span={8}>

        </Col>
      </Row>
    </>
  );
}
