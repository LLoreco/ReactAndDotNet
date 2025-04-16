import '../myStyles/HeaderStyle.css'
import NextTask from './HeaderComponents/NextTask';
import CreateTaskButton from './HeaderComponents/CreateTaskButton';
import { useEffect, useState } from 'react';

function Header({nextTask, timer}){

    const [activeTask, setActiveTask] = useState(null);
    
    const requestOptionsActiveTask = {
        method: "GET",
        redirect: "follow"
      };
      useEffect(() => {
        fetch("http://localhost:5016/api/Tasks/GetActiveTask", requestOptionsActiveTask)
            .then((response) => response.json())
            .then((result) => {
                if (result.IsSuccess && result.Result) {
                    setActiveTask(result.Result); // Извлекаем Result, если задача существует
                } else {
                    console.error('Ошибка при получении активной задачи');
                }
            })
            .catch((error) => console.error(error));
    }, []);

    

    return(
        <div className="HeaderBackground">
            {activeTask  &&  (
                <div className='HeaderActiveTask'>
                    {activeTask.TaskName}
                </div>
            )}
            <NextTask nextTask={nextTask} timer={timer}/>
            <CreateTaskButton />
        </div>
    );
}

export default Header;