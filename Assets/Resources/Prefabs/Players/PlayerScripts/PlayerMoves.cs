using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidade de movimento do jogador
    public float rotationSpeed = 10f; // Velocidade de rotação do jogador
    Vector3 movement;

    private CharacterController controller; // Componente CharacterController do jogador
    private InputControllers inputController;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        inputController = GetComponent<InputControllers>();
    }

    void Update()
    {
        MovePlayer(); // Movimentar o jogador
        RotatePlayer(); // Rotacionar o jogador em direção ao cursor
    }

    void MovePlayer()
    {
       
        // Obter entrada do teclado para movimento
        float moveHorizontal = inputController.movimentoHorizontal;
        float moveVertical = inputController.movimentoVertical;

        // Calcular a direção de movimento
        movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = transform.TransformDirection(movement); // Converter para coordenadas locais
        movement *= moveSpeed * Time.deltaTime;
       
        // Mover o jogador usando o CharacterControlle
        controller.Move(movement);
        movement.Normalize();
        if (inputController.Run)
        {
            RunPlayer();
        }
    }
    void RunPlayer() 
    {
        controller.Move(movement * 5 * Time.deltaTime);
        movement.Normalize();
    }

    void RotatePlayer()
    {
       // Obter a posição do mouse na tela
    Vector3 mousePosition = Input.mousePosition;

    // Converter a posição do mouse de pixels para coordenadas do mundo
    mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - transform.position.y));

    // Calcular a direção para a qual o jogador deve se orientar
    Vector3 lookDirection = mousePosition - transform.position;
    lookDirection.y = 0f; // Garantir que o jogador não rotacione no eixo Y

    // Rotacionar o jogador diretamente em direção à direção calculada sem suavização
    Quaternion rotation = Quaternion.LookRotation(lookDirection);
    transform.rotation = rotation;
    
    }
}