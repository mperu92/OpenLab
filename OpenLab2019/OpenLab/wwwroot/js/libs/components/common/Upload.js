/* eslint-disable react/jsx-props-no-spreading */
import React from 'react';
import PropTypes from 'prop-types';
import {
    Button, Icon, Upload as AntUpload,
} from 'antd';


const Upload = ({
    label,
    error,
    inputName,
    ...props
}) => {
    let wrapperClass = 'form-group';
    if (error && error.length > 0) {
      wrapperClass += '  has-error';
    }
    return (
        <div className={wrapperClass}>
          <label htmlFor={inputName}>{label}</label>
          <div className="field">
            <AntUpload {...props}>
                <Button>
                    <Icon type="upload" />
                    Click to Upload
                </Button>
            </AntUpload>
            {error && <div className="alert alert-danger">{error}</div>}
          </div>
        </div>
      );
    // name: 'file',
    // action: 'https://www.mocky.io/v2/5cc8019d300000980a055e76',
    // headers: {
    //   authorization: 'authorization-text',
    // },
    // onChange(info) {
    //   if (info.file.status !== 'uploading') {
    //     console.log(info.file, info.fileList);
    //   }
    //   if (info.file.status === 'done') {
    //     message.success(`${info.file.name} file uploaded successfully`);
    //   } else if (info.file.status === 'error') {
    //     message.error(`${info.file.name} file upload failed.`);
    //   }
    // },
  };


Upload.propTypes = {
    label: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    inputName: PropTypes.string.isRequired,
    placeholder: PropTypes.string,
    value: PropTypes.string,
    name: PropTypes.string,
    error: PropTypes.string,
    action: PropTypes.string,
    multiple: PropTypes.bool,
    headers: PropTypes.shape({
        authorization: PropTypes.string,
    }),
};

Upload.defaultProps = {
    placeholder: '',
    value: '',
    error: '',
    name: 'file',
    action: '/api/commonApi/uploadFile',
    multiple: true,
    headers: {
        authorization: 'authorization-text',
    },
};

export default Upload;
