import { useState, useEffect } from 'react';
import { Button, Input, Select, notification } from 'antd';
import { CheckOutlined } from '@ant-design/icons';

const Home = () => {

  const [loginAdd, setLoginAdd] = useState('123')
  const [mySelect, setMySelect] = useState('');
  const handleChangeMySelect = (value) => {
    setMySelect(value);

    notification.info({
      message: "Info",
      description: (
        <>
          {value}
        </>
      )
    });
  };

  const [dataSelect, setDataSelect] = useState([]);

  const FillSelect = () => {
    const requestOptions = {
      method: 'GET',
      headers: { 'Content-Type': 'application/json' }
    };
    fetch(`http://localhost:36449/My/FillSelect`, requestOptions)
      .then(response => {
        return response.json()
      })
      .then(data => {
        //console.log(data)
        setDataSelect(data);
      })
  }

  const MyClick = () => {
    //1setLoginAdd('hello step123')
    FillSelect();
  }

  useEffect(() => {
    FillSelect();
  }, []);

  return (
    <div>
      <h1>Hello, world!</h1>

      <Button
        type='primary'
        icon={<CheckOutlined />}
        // onClick={() => {
        //   alert('hello step')
        // }}
        onClick={MyClick}
      />

      <Input
        placeholder="Input login"
        value={loginAdd}
        onChange={(e) => setLoginAdd(e.target.value)}
        style={{
          width: 252, marginLeft: 137
        }}
      />

      <Select
        style={{
          width: 252, marginLeft: 10
        }}
        showSearch
        status="error"
        //defaultValue="2"
        value={mySelect}
        optionFilterProp="children"
        onChange={handleChangeMySelect}
        filterOption={(input, option) => option.children.toLowerCase().includes(input.toLowerCase())}
      >
        {dataSelect.map((z) => (
          <Option key={z.value}>{z.text}</Option>
        ))}
      </Select>
    </div>
  );
}
export default Home;
