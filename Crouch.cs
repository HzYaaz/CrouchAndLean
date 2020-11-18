        private float target_height = 1.8f;
        private float previous_y = 0;
        private bool is_crouching = false;

#region Basic Crouch
            previous_y = m_CharacterController.transform.position.y - m_CharacterController.height / 2 - m_CharacterController.skinWidth;
            //previous_y = 0f;       
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (is_crouching == false)
                {
                    is_crouching = true;
                    target_height = 0.9f;
                    m_RunSpeed = 1.3f;
                    m_WalkSpeed = 1.1f;
                }
            }
            if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                if(is_crouching == true)
                {
                    is_crouching = false;
                    target_height = 1.8f;
                    m_RunSpeed = 6f;
                    m_WalkSpeed = 3f;

                }
            }
            m_CharacterController.height = Mathf.Lerp(m_CharacterController.height,target_height,5f * Time.deltaTime);
            m_Camera.transform.position = Vector3.Lerp(m_Camera.transform.position, new Vector3(m_Camera.transform.position.x, m_CharacterController.transform.position.y + target_height / 2 - 0.1f, m_Camera.transform.position.z), 5f * Time.deltaTime);
            m_CharacterController.transform.position = Vector3.Lerp(m_CharacterController.transform.position, new Vector3(m_CharacterController.transform.position.x, previous_y + target_height / 2 + m_CharacterController.skinWidth, m_CharacterController.transform.position.z), 5f * Time.deltaTime);

            #endregion
